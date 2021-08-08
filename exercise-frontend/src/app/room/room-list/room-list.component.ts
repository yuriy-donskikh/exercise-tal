import { error, stringify } from '@angular/compiler/src/util';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { Subscription } from 'rxjs';
import { IRoom } from '../Models/room';
import { RoomService } from '../room.service';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.scss']
})
export class RoomListComponent implements OnInit, OnDestroy {
  pageTitle:string = 'Room List'
  errorMessage: string = '';
  sub!:Subscription;

  rooms:IRoom[] = [];

  showTimeSheet=false;

  selectedRoom?:IRoom;

  constructor(private roomService: RoomService, private router:Router) { }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.showTimeSheet = false;
    this.selectedRoom = undefined;
    this.sub = this.roomService.getAllRooms().subscribe({
      next: rooms => {
        this.rooms = rooms; 
      },
      error: err => this.errorMessage = err
    });
  }

  displayRoomText(room:IRoom){
    return `${room.name} - ${moment(room.date).format("DD/MM/YYYY")}`
  }

  roomSelected(event:any){
    this.selectedRoom = event.value;
    if(this.selectedRoom != null){
      this.showTimeSheet=true;
    }
  }

  roomDelete(){
    if(this.selectedRoom != null){
      this.roomService.deleteRoom(this.selectedRoom.roomId).subscribe({
        next:room=>{
          this.ngOnInit();
        },
        error: err => this.errorMessage = err
      });    
    }
  }

  addRoom(){
    this.router.navigateByUrl("/room/add")
  }
}
