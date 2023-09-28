import EventService from "../../../../services/event.service";

class StudentMarkAssessmentService extends EventService {
    
    constructor() {
        super({
            switchSemester: [],
            switchSummary: [],
        });
    }
}

export default new StudentMarkAssessmentService();