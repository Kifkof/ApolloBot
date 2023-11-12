import { Component, inject } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { BASE_URL } from 'src/app/app.config';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { UiModule } from 'src/app/ui/ui.module';
import { LMarkdownEditorModule } from 'ngx-markdown-editor';
import { FormsModule } from '@angular/forms';
import { EmbededMsgFieldComponent } from 'src/app/components/embeded-msg-field/embeded-msg-field.component';

@Component({
  selector: 'app-embeded-message',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    NgOptimizedImage,
    UiModule,
    LMarkdownEditorModule,
    FormsModule,
    EmbededMsgFieldComponent,
  ],
  templateUrl: './embeded-message.component.html',
  styleUrl: './embeded-message.component.scss',
})
export class EmbededMessageComponent {
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
