import {
  Component,
  EventEmitter,
  HostBinding,
  Input,
  Output,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-embeded-msg-field',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './embeded-msg-field.component.html',
  styleUrl: './embeded-msg-field.component.scss',
})
export class EmbededMsgFieldComponent {
  @Input() field: any;
  @Output() fieldChange = new EventEmitter();
  @HostBinding('class') classes = ['flex'];
}
