export default class EventService {

    events;

    constructor(events) {
        this.events = events;
    }

    /**
     * Component A đăng ký theo dõi sự kiện ở component B
     * @param {string} event Tên sự kiện phát ra ở component B (VD: "addUser", "sendEmail"). 
     * @param {{component: HTMLElement, eventHandler: Function}} component Thông tin về component A 
     * (bao gồm object this và hàm handler).
     * @author La Trong Nghia <leonghiacnn@gmail.com>
     */
    subscribe(event, component) {
        if (!this.events[event]) {
            this.events[event] = [];
            this.events[event].push(component);
        } else {
            let isDuplicated = false
            this.events[event].forEach((currentElement, currentIndex) => {
                
                if (currentElement.component.constructor.name == component.component.constructor.name) {
                    
                    isDuplicated = true;
                    return;
                }
            });
            if (!isDuplicated) {
                this.events[event].push(component);
            }
        }
    }

    /**
     * Phát sự kiện ở component B và kích hoạt hàm handler ở component A
     * @param {string} event Tên sự kiện ở component B. 
     * @param {Object} data Dữ liệu truyền từ component B sang component A.
     * @author La Trong Nghia <leonghiacnn@gmail.com>
     */
    trigger(event, data) {
        if (!this.events[event]) {
            return;
        }
        this.events[event].forEach(component => {
            component.eventHandler.call(component.component, data);
        });
    }

    unSubscribe(event, component) {
        if (!this.events[event]) {
            return;
        }

        this.events[event].forEach((currentElement, currentIndex) => {
            if (currentElement.component.constructor.name === component.constructor.name) {
                this.events[event].splice(currentIndex, 1);
            }
        })
    }

}