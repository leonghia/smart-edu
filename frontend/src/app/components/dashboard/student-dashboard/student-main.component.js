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
        <div class="lg:pl-20" style="height: calc(100% - 4rem);">
            <div class="main-wrapper px-4 py-10 sm:px-6 lg:px-8 lg:py-6 h-full overflow-scroll">
                <student-home></student-home>
            </div>
        </div>   
        `;
    }

    handleSwitch(id) {
        switch (id) {
            case 0: 
                this.firstElementChild.firstElementChild.innerHTML = `<student-home></student-home>`;             
                break;
            case 1:
                this.firstElementChild.firstElementChild.innerHTML = `<academic-progress><academic-progress/>`;
                break;
            case 2:
                this.firstElementChild.firstElementChild.innerHTML = `<student-ma><student-ma/>`;
                break;
            case 3:
                this.firstElementChild.firstElementChild.innerHTML = `<timetable-schedule><timetable-schedule/>`;
                break;
            case 4:
                this.firstElementChild.firstElementChild.innerHTML = `<student-ec><student-ec/>`;
                break;
            case 5:
                this.firstElementChild.firstElementChild.innerHTML = `<student-doc><student-doc/>`;
                break;
            default:
                console.log("default");
                break;
        }
    }
}

customElements.define("student-main", StudentMainComponent);