import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { AddRoom } from '../Models/addRoom';
import { RoomService } from '../room.service';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.scss']
})
export class AddRoomComponent implements OnInit {
  roomForm: FormGroup;

  constructor(private fb: FormBuilder, private roomService: RoomService, private router: Router) { 
    this.roomForm = this.fb.group({
      roomName: ["", Validators.required],
      roomDate: ["", Validators.required]
    }); 
  }

  ngOnInit(): void {
    this.roomForm.reset();
  }

  onSubmit(){
    if(this.roomForm.valid){
      if(this.roomForm.dirty){
        const room = {
          name: this.roomForm.value.roomName, 
          date: moment(this.roomForm.value.roomDate).format("YYYY-MM-DD")
        };
        this.roomService.addRoom(room).subscribe({
          next:room=>{
            this.router.navigateByUrl('/room');
          },
          error: err => console.log(err)
        });    
      }
    }
  }
}
