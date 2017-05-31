using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.DAL.Entity
{
    public class Page
    {
        //默认分页大小
        public const int DefaultSize = 5;
        private int count = 0; //记录数
        private int pageCount = 0; //总分页数
        private int pageSize = DefaultSize; //分页大小
        private int pageNumber = 1; //当前页码
        private int skip = 0; //要跳过的值

        public int Count
        {
            get
            {
                Compute();
                return count;
            }
            set
            {
                count = value;
            }
        }

        public int PageCount
        {
            get
            {
                Compute();
                return pageCount;
            }
        }

        public int PageSize
        {
            get
            {
                Compute();
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }

        public int PageNumber
        {
            get
            {
                Compute();
                return pageNumber;
            }
            set
            {
                pageNumber = value;
            }
        }

        public int Skip
        {
            get
            {
                Compute();
                return skip;
            }
        }

        //计算分页信息
        private void Compute()
        {
            if (count <= 0) //没有记录的情况
            {
                count = 0;
                pageCount = 0;
                skip = 0;
                return;
            }
            //计算分页大小
            if (pageSize < 1)
            {
                pageSize = DefaultSize;
            }
            //计算分页总数
            pageCount = count / pageSize;
            if (count % pageSize > 0)
            {
                pageCount++;
            }
            //校验当前页码
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageNumber > pageCount)
            {
                pageNumber = pageCount;
            }
            //计算跳过的记录数
            skip = pageSize * (pageNumber - 1);
        }

    }
}