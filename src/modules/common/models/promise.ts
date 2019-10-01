import guidHelper from "../helpers/guidHelper";
export class PromiseFactory{
    public static create():Promise{
        return new Promise();   
    }
}
enum PromiseStatus{
    Subscribe=1
}
export class Promise{
    private subPromies:Array<string>=[];
    private status:PromiseStatus;
    private subscribeCallback: any;
    private callback:any;
    private id:string;
    constructor(){
        this.id=guidHelper.createNew();
    }
    public subscribe(callback: any):void{
        this.status=PromiseStatus.Subscribe;
        this.subscribeCallback=callback;
    }
    public resolve():void{
        if(this.status==PromiseStatus.Subscribe){
            this.subscribeCallback(this);
        }
    }

    public resolveAll(subPromise: Promise):void{
        //1. promise me có danh sách promise con.
        //2. khi nào promise con xong, sẽ thông báo mẹ
        //1
        // subPromises: danh sachs promise con đang chạy chưa xong
        this.subPromies.push(subPromise.id);
        let self=this;
        //2. khi nào promise con xong, sẽ thông báo mẹ
        subPromise.subscribe((def: Promise)=>{
            
            // private, void, 1 params : promise
            self.onSubPromiseCompleted(def);
        });
    }
    
    
    //5. nếu còn, thì đợi tiếp
    
    private onSubPromiseCompleted(def: Promise):void{
        //3. mẹ sẽ loại bỏ promise khỏi danh sách hàng đợi các promise con đang chạy
        this.subPromies.removeItem(def.id);
        //4. mẹ kiểm tra còn ai đang chạy ko
        if(this.subPromies.isEmpty()){
            //6. nếu ko thì mẹ đã hoàn thành
            this.processCallback();
        }
    }
    private processCallback():void{
        this.callback();
    }
}
