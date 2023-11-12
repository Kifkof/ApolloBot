import { NgModule } from '@angular/core';
import { ButtonStyleDirective } from './directives/styles/button-style.directive';
import { InputStyleDirective } from './directives/styles/input-style.directive';
import { LabelStyleDirective } from './directives/styles/label-style.directive';

const exported = [
  ButtonStyleDirective,
  InputStyleDirective,
  LabelStyleDirective,
];

@NgModule({
  declarations: [],
  imports: exported,
  exports: exported,
})
export class UiModule {}
