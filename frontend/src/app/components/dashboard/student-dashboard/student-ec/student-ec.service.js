import EventService from "../../../../services/event.service";

class StudentExtraClassService extends EventService {

    constructor() {
        super({
            showQuickview: []
        });
    }
}

export default new StudentExtraClassService();