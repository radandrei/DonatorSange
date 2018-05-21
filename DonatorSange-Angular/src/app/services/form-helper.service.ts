import { Injectable } from '@angular/core';
import { FormGroup } from "@angular/forms";

@Injectable()
export class FormHelperService {
    public showErrorMessage(form: FormGroup, controlName: string, validator: string): boolean {
        if (controlName === '') { return false; };
        if(!form)
            return false;
        let control = form.get(controlName);
        if ((control || null) === null) { return false; };
        
        return validator === ''
            ? control.invalid && control.touched
            : control.hasError(validator) && control.touched;
    }

    public errorMessageForRequired(controlName: string): string {
        return `${controlName}, please.`;
    }

    public errorMessageForValid(controlName: string): string {
        return `We're sorry, but you've entered an invalid ${controlName}.`;
    }

    public errorMessageForMaxLength(controlName: string, max: number) {
        return `Oops! We have a ${max} character max.`;
    }

    public errorMessageForMinLength(controlName: string, min: number) {
        return `Oops! We have a ${min} character min.`;
    }

    public errorMessageForRange(controlName: string, min: number, max: number) {
        return `The ${controlName} value should be between ${min} and ${max}`;
    }

}