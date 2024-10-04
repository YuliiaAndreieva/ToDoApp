import { environment } from '../../environments/environment.development';

export const API_URLS = {
  AUTH: {
    REGISTER: `${environment.apiBaseUrl}/api/auth/register`,
    LOGIN: `${environment.apiBaseUrl}/api/auth/login`,
  },
  TASK: {
    GET_ALL: `${environment.apiBaseUrl}/api/tasks`,
    GET: (id: number) => `${environment.apiBaseUrl}/api/tasks/${id}`,
  },
  CATEGORY: {
    GET_ALL: `${environment.apiBaseUrl}/api/categories`,
  },
};
