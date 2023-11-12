import { Component } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { EmbededMsgFieldComponent } from './components/embeded-msg-field/embeded-msg-field.component';
import { FormsModule } from '@angular/forms';
import { InputFieldDirective } from './directives/input-field.directive';

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
}
