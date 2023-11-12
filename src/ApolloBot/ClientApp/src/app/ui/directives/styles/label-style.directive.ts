import { Directive, HostBinding } from '@angular/core';

@Directive({
  selector: 'label',
  standalone: true,
})
export class LabelStyleDirective {
  @HostBinding('class')
  styles = ['text-base', 'font-bold'];
}
