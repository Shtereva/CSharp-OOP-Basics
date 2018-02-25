public class Mission : IMission
{
    public string CodeName { get; set; }
    public StateType State { get; set; }

    public Mission(string codeName, StateType state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public void CompleteMission()
    {
        //this.State = StateType.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
