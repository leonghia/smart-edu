import EventService from "../../../../services/event.service";

class StudentExtraClassService extends EventService {
    constructor() {
        super({
            showQuickview: [],
            registered: []
        });
    }
}

export default new StudentExtraClassService();