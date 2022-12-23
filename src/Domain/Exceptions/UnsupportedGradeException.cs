namespace CleanArchitecture.Domain.Exceptions;

public class UnsupportedGradeException : Exception{
    public UnsupportedGradeException(string grade)
    {
        string[] unsupportedGrade = { "E8","F9","Failed"};
        if(unsupportedGrade.Contains(grade))
        {
            throw new Exception("E8 or Failed is not allowed");
        }

    }
}