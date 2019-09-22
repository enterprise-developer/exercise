import { IIoCRegistration } from "../models/enums";
import { IIoCBuilder } from "./iiocBuilder";
import { IoCBuilderFactory } from "./iocBuilderFactory";
import { Injector } from "@angular/core";
export class IoCFactory {
    public static create(): IoCContainer {
        return new IoCContainer()
    }
}

export class IoCContainer implements IIoCContainer {
    private registrations: Array<any>;
    private injector: Injector;
    public import(registrations: any[]): void {
        this.registrations = registrations;
    }

    public resolve(nameOrType: any): any {
        if (typeof (nameOrType) != "string") {
            return this.getAngularType(nameOrType);
        }
        let registration: IIoCRegistration = this.registrations.firstOrDefault((item: IIoCRegistration) => {
            return item.name == nameOrType;
        });

        if (!registration) {
            throw String.format("invalid registration with name: {0}", nameOrType);
        }

        let iocBuilder: IIoCBuilder = IoCBuilderFactory.create(registration);
        return iocBuilder.build();
    }

    private getAngularType(type: any): any {
        return this.injector.get(type);
    }

    public setInjector(injector: Injector): void {
        this.injector = injector;
    }

}