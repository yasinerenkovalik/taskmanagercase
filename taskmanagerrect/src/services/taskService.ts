import type { Task, CreateTaskRequest, UpdateTaskRequest } from '../types/Task';

const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5001';
const API_TASKS_URL = `${API_BASE_URL}/api/tasks`;

export const taskService = {
 
  async getAllTasks(): Promise<Task[]> {
    try {
      const response = await fetch(API_TASKS_URL, {
        method: 'GET',
        headers: {
          'accept': '*/*'
        }
      });
      
      if (!response.ok) {
        return [];
      }
      
      const data = await response.json();
      console.log('API Response:', data); 
      
   
      if (data && Array.isArray(data.data)) {
      
        return data.data;
      } else if (Array.isArray(data)) {
      
        return data;
      } else {
       
        return [];
      }
      
    } catch (error) {
      console.error('API Hatası:', error);
      return [];
    }
  },

 
  async getTaskById(id: string): Promise<Task | null> {
    try {
      const response = await fetch(`${API_TASKS_URL}/${id}`, {
        method: 'GET',
        headers: {
          'accept': '*/*'
        }
      });
      
      if (!response.ok) {
        throw new Error('Task getirilemedi');
      }
      
      const result = await response.json();
      console.log('Task Detail Response:', result);
      
    
      if (result && result.data) {
        return result.data;
      }
      
      return null;
    } catch (error) {
      console.error('Task detay hatası:', error);
      return null;
    }
  },


  async createTask(task: CreateTaskRequest): Promise<Task> {
    const response = await fetch(API_TASKS_URL, {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(task)
    });
    
    if (!response.ok) {
      throw new Error('Task eklerken hata oluştu');
    }
    
    return response.json();
  },


  async updateTask(task: UpdateTaskRequest): Promise<Task> {
    const response = await fetch(`${API_TASKS_URL}/${task.id}/status`, {
      method: 'PUT',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(task)
    });
    
    if (!response.ok) {
      throw new Error(`Task güncellerken hata oluştu: ${response.status} ${response.statusText}`);
    }
    
    return response.json();
  }
};