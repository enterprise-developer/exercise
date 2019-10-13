import { Directive, Input, HostListener, ElementRef } from "@angular/core";

@Directive({
    selector: "[numeric]"
})
export class Numeric {
    @Input("numericType") numericType: string;// number | decimal

    private specialKeys: Array<string> = ['Backspace', 'Tab', 'End', 'Home', '-'];
    private el: ElementRef;

    private regex: any = {
        number: new RegExp(/^\d+$/),
        decimal: new RegExp(/^[0-9]+(\.[0-9]*){0,1}$/g)
    };
    constructor(el: ElementRef) {
        this.el = el;
    }

    @HostListener('keyDown', ['$event'])
    public onKeyDown(event: KeyboardEvent) {
        if (this.specialKeys.indexOf(event.key) !== -1) {
            return;
        }

        let current: string = this.el.nativeElement.value;
        let next: string = current.concat(event.key);
        if (next && !String(next).match(this.regex[this.numericType])) {
            event.preventDefault();
        }
    }
}