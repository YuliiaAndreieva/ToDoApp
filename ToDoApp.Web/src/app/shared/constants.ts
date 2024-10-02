import { environment } from '../../environments/environment.development';

export const API_URLS = {
  AUTH: {
    REGISTER: `${environment.apiBaseUrl}/api/auth/register`,
    LOGIN: `${environment.apiBaseUrl}/api/auth/login`,
  },
  TASKS: {},
};
