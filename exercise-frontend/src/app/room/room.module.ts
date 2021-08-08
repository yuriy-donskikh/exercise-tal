import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoomRoutingModule } from './room-routing.module';
import { RoomComponent } from './room.component';
import { RoomListComponent } from './room-list/room-list.component';
import { MaterialModule } from './shared/material.module';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { AddRoomComponent } from './add-room/add-room.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    RoomComponent,
    RoomListComponent,
    TimeSheetComponent,
    AddRoomComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MaterialModule,
    RoomRoutingModule
  ]
})
export class RoomModule { }
