import guidHelper from "../helpers/guidHelper";
export class PromiseFactory{
    public static create():Promise{
        return new Promise();
    }
}
enum PromiseStatus{
    None = 0,
    Fail = 1,
    Success = 2,
    Subscribe = 3
}
export class Promise{
    private data: any;
    private resolveCallback: any;
    private errorCallback: any;
    private subscribeCallback: any;
    private errors: any;
    private status: PromiseStatus=PromiseStatus.None;
    private queue:Array<string>=[];
    private id:string = guidHelper.newGuid();
    public resolveAll(def: Promise):Promise{
        let self=this;
        self.queue.push(def.id);
        console.log(this.queue);
        def.subscribe((pro: Promise)=>{
            self.onPromiseCompleted(pro);
        }, false);
        return self;
    }
    public onPromiseCompleted(pro: Promise):Promise{
        this.queue=this.queue.remove(pro.id);
        console.log("Oncompleted", this.queue)
        if(this.queue.isEmpty()){
            console.log("Empty")
            this.status=PromiseStatus.Success;
            this.processCallback();
        }
        return this;
    }
    public subscribe(subscriberCallback: any, isDataOnly:boolean = true):Promise{
        this.status=PromiseStatus.Subscribe;
        this.subscribeCallback=subscriberCallback;
        if(isDataOnly){
            this.subscribeCallback=(pro: Promise)=>{
                subscriberCallback(pro.data);
            };    
        }
        return this;
    }
    public error(callback: any):Promise{
        this.errorCallback=callback;
        this.processCallback();
        return this;
    }
    public reject(errors?: any):Promise{
        this.status=PromiseStatus.Fail;
        this.errors=errors;
        this.processCallback();
        return this;
    }
    public resolve(data?: any): Promise{
        this.status=this.status!=PromiseStatus.Subscribe?PromiseStatus.Success:this.status;
        this.data=data;
        this.processCallback();
        return this;
    }
    private processCallback(){
        if(this.resolveCallback && this.status==PromiseStatus.Success){
            this.resolveCallback(this.data);
        }

        if(this.errorCallback && this.status==PromiseStatus.Fail){
            this.errorCallback(this.errors);
        }

        if(this.subscribeCallback && this.status==PromiseStatus.Subscribe){
            this.subscribeCallback(this);
        }
    }
    public then(callback: any): Promise{
        if(!!this.resolveCallback){
            console.log("resolvecallback has value");
        }
        this.resolveCallback=callback;
        this.processCallback();
        return this;
    }
}