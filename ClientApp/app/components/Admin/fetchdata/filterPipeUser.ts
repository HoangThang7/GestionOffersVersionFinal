import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filterUser',
    pure: false
})

export class FilterPipeUser implements PipeTransform {

    transform(value: any[], filterBy: string): any[] {

        filterBy = filterBy.toLocaleUpperCase();

        return filterBy ? value.filter(item => item.firstName.indexOf(filterBy) !== -1) : value;
   }
}