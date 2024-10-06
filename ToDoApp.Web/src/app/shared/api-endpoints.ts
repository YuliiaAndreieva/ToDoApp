import { environment } from '../../environments/environment';

export const API_URLS = {
  AUTH: {
    REGISTER: `${environment.apiBaseUrl}/api/auth/register`,
    LOGIN: `${environment.apiBaseUrl}/api/auth/login`,
  },
  TASK: {
    BASE_URL: `${environment.apiBaseUrl}/api/tasks`,
    GET_BY_ID: (id: number) => `${environment.apiBaseUrl}/api/tasks/${id}`,
  },
  CATEGORY: {
    BASE_URL: `${environment.apiBaseUrl}/api/categories`,
  },
};
