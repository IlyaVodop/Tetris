
public delegate void OnScoreSend(int score);
public interface IScoreSender
{
    event OnScoreSend OnScoreSend;
}
