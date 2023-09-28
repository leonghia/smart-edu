export class DocumentFilterRequestParams {
    // public int SubjectId { get; set; } = 0;
    // public int FromNumbersOfRating { get; set; } = 0;
    // public int ToNumbersOfRating { get; set; } = 0;
    // public double FromRating { get; set; } = 0;
    // public double ToRating { get; set; } = 0;
    subjectId;
    fromNumbersOfRating;
    toNumbersOfRating;
    fromRating;
    toRating;

    constructor(subjectId = 0, fromNumbersOfRating = 0, toNumbersOfRating = 0, fromRating = 0, toRating = 0 ) {
        this.subjectId = subjectId;
        this.fromNumbersOfRating = fromNumbersOfRating;
        this.toNumbersOfRating = toNumbersOfRating;
        this.fromRating = fromRating;
        this.toRating = toRating;
    }
}