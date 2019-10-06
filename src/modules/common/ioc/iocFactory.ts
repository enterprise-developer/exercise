import { IIoCRegistration } from "../models/enums";
import { IIoCBuilder } from "./builder/iiocBuilder";
import { IoCBuilderFactory } from "./builder/iocBuilderFactory";
import { Injector } from "@angular/core";

export class IoCFactory {
    public static create(): IIoCContainer {
        return new IoCContainer();
    }
}

export class IoCContainer implements IIoCContainer {
    private registrations: Array<IIoCRegistration>;
    private injector: Injector;

    public import(registrations: Array<IIoCRegistration>): void {
        this.registrations = registrations;
    }

    public resolve(nameOrType: string): any {
        if (!nameOrType) {
            throw "Cannot resolve registration without nameOrType!";
        }

        if (typeof (nameOrType) != "string") {
            return this.getAngularType(nameOrType);
        }

        let registration: IIoCRegistration = this.registrations.firstOrDefault((item: IIoCRegistration) => {
            return item.name == nameOrType;
        });

        if (!registration) {
            throw String.format("Cannot found registration with name:{0}", nameOrType);
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