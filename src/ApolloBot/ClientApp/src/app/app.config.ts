import { ApplicationConfig, Injectable, InjectionToken } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

export const BASE_URL = new InjectionToken<string>('BASE_URL');
export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    {
      provide: BASE_URL,
      useFactory: () => document.getElementsByTagName('base')[0]?.href,
      deps: [],
    },
  ],
};
