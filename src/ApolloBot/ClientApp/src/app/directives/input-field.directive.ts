import { Directive, HostBinding } from '@angular/core';

@Directive({
  selector: '[appInputField]',
  standalone: true,
})
export class InputFieldDirective {
  @HostBinding('class.shadow-[0_35px_60px_-15px_rgba(0,0,0,0.3)]')
  shadow: boolean = true;

  @HostBinding('class.text-base')
  textBase: boolean = true;
}
