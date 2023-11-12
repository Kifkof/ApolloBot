import { Routes } from '@angular/router';
import { EmbededMessageComponent } from './pages/embeded-message/embeded-message.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
  { path: 'sendEmbededMessage', component: EmbededMessageComponent },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];
