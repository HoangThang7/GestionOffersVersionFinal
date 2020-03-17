import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filter',
    pure: false
})

export class FilterPipe implements PipeTransform {

    transform(value: any[], filterBy: string): any[] {
         
       filterBy = filterBy.toLocaleUpperCase();
      return filterBy ? value.filter(item => item.code.indexOf(filterBy) !== -1) : value;     
   }
}