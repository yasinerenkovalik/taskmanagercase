import { useState, useEffect } from 'react';
import TaskList from './components/TaskList';
import TaskForm from './components/TaskForm';
import type { Task, CreateTaskRequest, UpdateTaskRequest } from './types/Task';
import { taskService } from './services/taskService';
import './App.css'

function App() {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [editingTask, setEditingTask] = useState<Task | null>(null);


  const loadTasks = async () => {
    try {
      setLoading(true);
      setError(null);
      const fetchedTasks = await taskService.getAllTasks();
      
      console.log('Fetched tasks:', fetchedTasks); // Debug için
      
     
      setTasks(fetchedTasks);
    } catch (err) {
      console.error('Task yükleme hatası:', err);
      setError(err instanceof Error ? err.message : 'Bir hata oluştu');
      setTasks([]);
    } finally {
      setLoading(false);
    }
  };


  useEffect(() => {
    loadTasks();
  }, []);

  const handleCreateTask = async (taskData: CreateTaskRequest) => {
    try {
      setLoading(true);
      await taskService.createTask(taskData);
      await loadTasks(); 
      setShowForm(false);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Task eklenirken hata oluştu');
    } finally {
      setLoading(false);
    }
  };

  
  const handleUpdateTask = async (taskData: UpdateTaskRequest) => {
    try {
      setLoading(true);
      await taskService.updateTask(taskData);
      await loadTasks(); 
      setShowForm(false);
      setEditingTask(null);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Task güncellenirken hata oluştu');
    } finally {
      setLoading(false);
    }
  };

 
  const handleFormSubmit = (taskData: CreateTaskRequest | UpdateTaskRequest) => {
    if ('id' in taskData) {
      handleUpdateTask(taskData);
    } else {
      handleCreateTask(taskData);
    }
  };

  const handleEditTask = async (task: Task) => {
    try {
      setLoading(true);
     
      const taskDetail = await taskService.getTaskById(task.id);
      
      if (taskDetail) {
        setEditingTask(taskDetail);
        setShowForm(true);
      } else {
        setError('Task detayları getirilemedi');
      }
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Task detayları getirilemedi');
    } finally {
      setLoading(false);
    }
  };

 
  const handleCancelForm = () => {
    setShowForm(false);
    setEditingTask(null);
  };

  return (
    <div className="app">
      <header className="app-header">
        <h1>Görev Yöneticisi</h1>
        <button 
          className="add-task-btn"
          onClick={() => setShowForm(true)}
          disabled={loading}
        >
          Yeni Görev Ekle
        </button>
      </header>

      <main className="app-main">
        {error && (
          <div className="error-message">
            {error}
            <button onClick={() => setError(null)}>×</button>
          </div>
        )}

        {loading && <div className="loading">Yükleniyor...</div>}

        <TaskList 
          tasks={tasks} 
          onEditTask={handleEditTask}
        />

        {showForm && (
          <TaskForm
            task={editingTask}
            onSubmit={handleFormSubmit}
            onCancel={handleCancelForm}
          />
        )}
      </main>
    </div>
  );
}

export default App
