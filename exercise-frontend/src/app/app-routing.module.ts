import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'room', loadChildren: () => import('./room/room.module').then(m => m.RoomModule) },
  { path: '', redirectTo: 'room', pathMatch: 'full' },
  { path: '**', redirectTo: 'room', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
