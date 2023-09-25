import EventService from "../../../../services/event.service";

class StudentDocumentService extends EventService {

    constructor() {
        super({
            totalPages: [],
            next: [],
            prev: []
        });
    }
}

export default new StudentDocumentService();