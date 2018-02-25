public interface IMission
{
    string CodeName { get; set; }
    StateType State { get; set; }

    void CompleteMission();
}
