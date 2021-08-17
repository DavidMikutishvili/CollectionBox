﻿using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class AlcoholTagRepository : GenericRepository<AlcoholTag>, IAlcoholTagRepository
    {
        public AlcoholTagRepository(DataContext context) : base(context)
        {
        }

        public void CreateTag(AlcoholTag tag)
        {
            Create(tag);
        }

        public void DeleteTag(int id)
        {
            Delete(id);
        }

        public IEnumerable<AlcoholTag> GetAllTags()
        {
            return GetAll();
        }

        public AlcoholTag GetTagById(int id)
        {
            return GetById(id);
        }

        public void UpdateTag(AlcoholTag tag)
        {
            Update(tag);
        }
    }
}