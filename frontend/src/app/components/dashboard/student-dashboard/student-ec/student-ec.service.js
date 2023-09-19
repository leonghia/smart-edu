import EventService from "../../../../services/event.service";

class StudentExtraClassService extends EventService {

    constructor() {
        super({
            showQuickview: [],
            refreshEcGrid: [],
            refreshEcListReg: [],
            refreshEcListBook: [],
        });
    }
}

export default new StudentExtraClassService();