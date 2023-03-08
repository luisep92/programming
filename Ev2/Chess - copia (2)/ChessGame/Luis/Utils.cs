using ChessLib;
using DAM;
using OpenTK.Windowing.Common.Input;

namespace Luis
{
    internal class Utils
    {
        #region UTILS
        public static bool IsInList(Position pos, List<Position> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (pos == list[i])
                    return true;
            }
            return false;
        }
        
        #endregion
    }
}
