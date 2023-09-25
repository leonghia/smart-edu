using System.Linq.Expressions;
using SmartEdu.Entities;
using SmartEdu.Models;

namespace SmartEdu.Helpers.FilterParamsAppender;

public static class FilterParamsAppender
{
    public static Func<Document, bool> AppendDocumentFilterParams(FilterDocumentParams filterDocumentParams)
    {
        Func<Document, bool> func1, func2, func3, func;
        func1 = func2 = func3 = d => true;

        if (filterDocumentParams.SubjectId != 0)
        {
            func1 = d => d.Teacher.SubjectId == filterDocumentParams.SubjectId;
        }
        if (filterDocumentParams.FromNumbersOfRating != 0 && filterDocumentParams.ToNumbersOfRating != 0)
        {
            func2 = d => d.NumbersOfRating >= filterDocumentParams.FromNumbersOfRating && d.NumbersOfRating <= filterDocumentParams.ToNumbersOfRating;
        }
        if (filterDocumentParams.FromRating != 0 && filterDocumentParams.ToRating != 0)
        {
            func3 = d => d.Rating >= filterDocumentParams.FromRating && d.Rating <= filterDocumentParams.ToRating;
        }
        func = d => func1(d) && func2(d) && func3(d);
        return func;
    }
}