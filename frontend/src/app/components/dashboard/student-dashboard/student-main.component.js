import studentSidebarService from "./student-sidebar.service";
export class StudentMainComponent extends HTMLElement {

    #currentTab;

    constructor() {
        super();
        studentSidebarService.subscribe("switch", {
            component: this,
            eventHandler: this.handleSwitch
        });
    }

    connectedCallback() {
        this.innerHTML = this.#render();
    }

    disconnectedCallback() {
        studentSidebarService.unSubscribe("switch", this);
    }

    #render() {
        
        return `
        <div class="mx-auto w-full pl-32 pr-10 py-12" style="height:calc(100% - 4rem);">
            <student-home></student-home>
        </div>   
        `;
    }

    handleSwitch(id) {
        switch (id) {
            case 0: 
                this.firstElementChild.innerHTML = `<student-home></student-home>`;             
                break;
            case 1:
                this.firstElementChild.innerHTML = `<student-ec></student-ec>`;             
                break;
            case 2:
                this.firstElementChild.innerHTML = `<student-material></student-material>`;
                break;
            case 3:
                this.firstElementChild.innerHTML = `<student-assessment></student-assessment>`;
                break;
            case 4:
                this.firstElementChild.innerHTML = `<student-timetable></student-timetable>`;
                break;
            case 5:
                this.firstElementChild.innerHTML = `<student-tool></student-tool>`;
                break;
            default:
                console.log("default");
                break;
        }
    }
}

customElements.define("student-main", StudentMainComponent);