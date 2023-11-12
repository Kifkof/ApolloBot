import { Component, ProviderToken, inject } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { EmbededMsgFieldComponent } from './components/embeded-msg-field/embeded-msg-field.component';
import { FormsModule } from '@angular/forms';
import { InputFieldDirective } from './directives/input-field.directive';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BASE_URL } from './app.config';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  imports: [
    CommonModule,
    RouterOutlet,
    EmbededMsgFieldComponent,
    FormsModule,
    NgOptimizedImage,
    InputFieldDirective,
    HttpClientModule,
  ],
})
export class AppComponent {
  model: any = {};
  addField() {
    if (!Array.isArray(this.model.fields)) {
      this.model.fields = [];
    }
    this.model.fields.push({});
  }
  httpClient = inject(HttpClient);
  baseUrl = inject(BASE_URL);
  sendMsg() {
    this.httpClient.post(this.baseUrl + 'sendEmbeded', this.model).subscribe();
  }
}
