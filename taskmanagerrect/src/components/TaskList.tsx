import React from 'react';
import { TaskStatus } from '../types/Task';
import type { Task } from '../types/Task';

interface TaskListProps {
  tasks: Task[];
  onEditTask: (task: Task) => void;
}

const TaskList: React.FC<TaskListProps> = ({ tasks, onEditTask }) => {
  const getStatusText = (status: TaskStatus): string => {
    switch (status) {
      case TaskStatus.Pending:
        return 'Bekliyor';
      case TaskStatus.InProgress:
        return 'Devam Ediyor';
      case TaskStatus.Completed:
        return 'Tamamlandı';
      default:
        return 'Bilinmiyor';
    }
  };

  const getStatusColor = (status: TaskStatus): string => {
    switch (status) {
      case TaskStatus.Pending:
        return 'linear-gradient(135deg, #ffeaa7, #fdcb6e)';
      case TaskStatus.InProgress:
        return 'linear-gradient(135deg, #74b9ff, #0984e3)';
      case TaskStatus.Completed:
        return 'linear-gradient(135deg, #55efc4, #00b894)';
      default:
        return 'linear-gradient(135deg, #ddd, #999)';
    }
  };

  return (
    <div className="task-list">
      <h2>Görevler</h2>
      {tasks.length === 0 ? (
        <p>Henüz görev yok.</p>
      ) : (
        <div className="tasks">
          {tasks.map((task) => (
            <div key={task.id} className="task-item">
              <div className="task-content">
                <h3>{task.title}</h3>
                <p>{task.description}</p>
                <span 
                  className="status-badge" 
                  style={{ background: getStatusColor(task.status) }}
                >
                  {getStatusText(task.status)}
                </span>
              </div>
              <button 
                className="edit-btn"
                onClick={() => onEditTask(task)}
              >
                Düzenle
              </button>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default TaskList;