import { Component, Input, OnInit } from '@angular/core';
import * as moment from 'moment';
import { IRoom } from '../Models/room';
import { IRoomTime } from '../Models/room-time';
import { RoomService } from '../room.service';

@Component({
  selector: 'app-time-sheet',
  templateUrl: './time-sheet.component.html',
  styleUrls: ['./time-sheet.component.scss']
})
export class TimeSheetComponent implements OnInit {
  @Input() room?: IRoom;
  constructor(private roomService: RoomService) { }

  ngOnInit(): void {
  }
  
  getTime(time:IRoomTime){
    return moment(time.time, ['HH:mm:ss']).format('HH:mm');
  }

  timeClicked(time:IRoomTime){
    if(this.room != null){
      time.available = !time.available;
      this.roomService.updateTime(this.room.roomId, time).subscribe({
        error:  err => {
          time.available = !time.available;
          console.log(err);
        }
      });
    }
  }
}
