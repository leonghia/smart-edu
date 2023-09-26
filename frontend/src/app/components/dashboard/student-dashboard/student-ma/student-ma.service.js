import EventService from "../../../../services/event.service";

class StudentMarkAssessmentService extends EventService {
    
    constructor() {
        super({
            switchTable: []
        });
    }
}

export default new StudentMarkAssessmentService();