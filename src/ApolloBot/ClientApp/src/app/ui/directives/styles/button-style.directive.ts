import { Directive, HostBinding } from '@angular/core';

@Directive({
  selector: 'button',
  standalone: true,
})
export class ButtonStyleDirective {
  @HostBinding('class')
  styles = ['font-bold', 'outline', 'outline-2', 'm-2', 'p-1', 'bg-white'];
}
