import React, { useState, useEffect } from 'react';
import type { Task, CreateTaskRequest, UpdateTaskRequest } from '../types/Task';
import { TaskStatus } from '../types/Task';

interface TaskFormProps {
  task?: Task | null;
  onSubmit: (task: CreateTaskRequest | UpdateTaskRequest) => void;
  onCancel: () => void;
}

const TaskForm: React.FC<TaskFormProps> = ({ task, onSubmit, onCancel }) => {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [status, setStatus] = useState<TaskStatus>(TaskStatus.Pending);

  useEffect(() => {
    if (task) {
      console.log('Form task data:', task); // Debug için
      setTitle(task.title || '');
      setDescription(task.description || '');
      setStatus(task.status ?? TaskStatus.Pending);
    } else {
      setTitle('');
      setDescription('');
      setStatus(TaskStatus.Pending);
    }
  }, [task]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    
    if (!title.trim() || !description.trim()) {
      alert('Başlık ve açıklama boş olamaz!');
      return;
    }

    if (task) {
 
      const updateRequest: UpdateTaskRequest = {
        id: task.id,
        title: title.trim(),
        description: description.trim(),
        status
      };
      onSubmit(updateRequest);
    } else {
    
      const createRequest: CreateTaskRequest = {
        title: title.trim(),
        description: description.trim(),
        status,
        isDeleted: false
      };
      onSubmit(createRequest);
    }
  };

  return (
    <div className="task-form-overlay">
      <div className="task-form">
        <h2>{task ? 'Görevi Düzenle' : 'Yeni Görev Ekle'}</h2>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="title">Başlık:</label>
            <input
              type="text"
              id="title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              placeholder="Görev başlığı"
              required
            />
          </div>
          
          <div className="form-group">
            <label htmlFor="description">Açıklama:</label>
            <textarea
              id="description"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              placeholder="Görev açıklaması"
              rows={4}
              required
            />
          </div>
          
          <div className="form-group">
            <label htmlFor="status">Durum:</label>
            <select
              id="status"
              value={status}
              onChange={(e) => setStatus(Number(e.target.value) as TaskStatus)}
            >
              <option value={TaskStatus.Pending}>Bekliyor</option>
              <option value={TaskStatus.InProgress}>Devam Ediyor</option>
              <option value={TaskStatus.Completed}>Tamamlandı</option>
            </select>
          </div>
          
          <div className="form-actions">
            <button type="button" onClick={onCancel} className="cancel-btn">
              İptal
            </button>
            <button type="submit" className="submit-btn">
              {task ? 'Güncelle' : 'Ekle'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default TaskForm;