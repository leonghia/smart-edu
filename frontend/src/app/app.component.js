import authService from "./services/auth.service.js";

export class AppComponent extends HTMLElement{

    // Dung de tao ra the <app-root> chua duoc dua vao DOM
    constructor(){
        super();  // super là contructor trong class cha (HTMLlement)
    }

    // Kich hoat khi <app-root> duoc dua vao DOM
    async connectedCallback(){
        if (!authService.checkToken()){
            // neu token khon ton tai
            this.innerHTML = `<app-login></app-login>`;
        }else{
            try{
                const data = await authService.getCurentUser();
                console.log(data.data);
            }catch(err){
                this.innerHTML = `<app-login></app-login>`;// hien thi trang dang nhap
            }
        }
    }

    // Kich hoat khi <app-root> bi xoa khoi DOM
    disconnectedCallback(){

    }

}

customElements.define("app-root",AppComponent);