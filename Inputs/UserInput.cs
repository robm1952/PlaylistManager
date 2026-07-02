using Microsoft.Extensions.Configuration;

namespace PlaylistManager.Inputs {
    internal class UserInput {
        private static IConfiguration? _config;
        public UserInput(IConfiguration configuration) {
            _config = configuration;
        }

        public int ConvertToInt(string value) {
            int retInt = FromString(value);
            if (retInt > 0 && !IsLTZero(retInt) && !IsZero(retInt))
            {
                return retInt;
            }
            else
            {
                return -1;
            }
        }

        private int FromString(string value) {
            bool success = int.TryParse(value, out int result);
            if (success)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private bool IsLTZero(int value) {
            if (value < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsZero(int value) {
            if (value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsInRange(int value) {
            if (value > 12000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
