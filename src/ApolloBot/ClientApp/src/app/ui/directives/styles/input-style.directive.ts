import { Directive, HostBinding } from '@angular/core';

@Directive({
  selector: 'input',
  standalone: true,
})
export class InputStyleDirective {
  @HostBinding('class')
  styles = ['text-base'];
}
