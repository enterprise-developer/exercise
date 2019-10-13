import { Directive, Input, HostListener, ElementRef } from "@angular/core";

@Directive({
    selector: "[numeric]"
})
export class Numeric {
    @Input("numericType") numericType: string; // number | decimal

    private specialKeys: Array<string> = ['Backspace', 'Tab', 'End', 'Home', '-'];
    private ui: ElementRef;
    private regex:any ={
        number: new RegExp(/^\d+$/),
        decimal:new RegExp(/^[0-9]+(\.[0-9]*){0,1}$/g)
    };

    constructor(el:ElementRef){
        this.ui = el;
    }

    @HostListener('keyDown', ['event'])
    public onKeyDown(event: KeyboardEvent): void {
        if (this.specialKeys.indexOf(event.key) !== -1) {
            return;
        }

        let current: string = this.ui.nativeElement.value;
        let next: string = current.concat(event.key);
        if (next && !String(next).match(this.regex[this.numericType])) {
            event.preventDefault;
        }
    }
}