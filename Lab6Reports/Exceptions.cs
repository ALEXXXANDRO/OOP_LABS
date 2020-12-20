using System;

namespace Lab6Reports
{
    public class ResolvedTask : Exception
    {
        public ResolvedTask() : base("Задача уже выполнена. Изменения недопустимы")
        {
        }
    }
    
    public class NotFound : Exception
    {
        public NotFound() : base("По данному ID ничего не найдено")
        {
        }
    }

    public class ForbiddenEdit : Exception
    {
        public ForbiddenEdit() : base("У сотрудника нет доступа к отчету")
        {
        }
    }
    
    public class ItIsNotDraft : Exception
    {
        public ItIsNotDraft() : base("Нельзя менять готовый отчет")
        {
        }
    }

}