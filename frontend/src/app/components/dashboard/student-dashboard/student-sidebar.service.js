import EventService from "../../../services/event.service";

class StudentService extends EventService {
    constructor() {
        super({
            switch: [],
        });
    }
}

export default new StudentService();