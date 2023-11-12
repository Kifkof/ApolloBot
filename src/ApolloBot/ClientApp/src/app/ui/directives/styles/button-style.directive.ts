import { Directive, HostBinding } from '@angular/core';

@Directive({
  selector: 'button',
  standalone: true,
})
export class ButtonStyleDirective {
  @HostBinding('class')
  styles = [
    'font-bold',
    'outline',
    'outline-1',
    'm-2',
    'p-1',
    'bg-white',
    'border',
    'hover:border-slate-400',
  ];
}
