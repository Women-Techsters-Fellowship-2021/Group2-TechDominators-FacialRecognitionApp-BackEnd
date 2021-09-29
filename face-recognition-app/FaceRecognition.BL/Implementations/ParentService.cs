using System;
using System.Linq;
using FaceRecognition.DB;
using FaceRecognition.DTOs;
using FaceRecognition.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FaceRecognition.BL
{
    public class ParentService : IParentService
    {
        private readonly RecognitionContext _context;
        public ParentService(RecognitionContext context)
        {
            _context = context;
        }

        //    adds new parent/guardian
        public async Task<ParentResponseDTO> CreateParent(ParentRequest request)
        {
            Parent parent = ParentMappings.GetParent(request);
            await _context.AddAsync(parent);

            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                throw new ArgumentException("Cannot create student at this time");
            }
            return ParentMappings.GetParentResponse(parent);
        }


        //   gets a particular parent using their id
        public async Task<ParentResponseDTO> GetParent(string parentId)
        {
            Parent parent = await _context.Parents
            .FirstOrDefaultAsync(parent => parent.Id == parentId);
            if (parent is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return ParentMappings.GetParentResponse(parent);
        }
        //   gets a particular parent using their email
        public async Task<ParentResponseDTO> GetParentByEmail(string email)
        {
            Parent parent = await _context.Parents
            .FirstOrDefaultAsync(parent => parent.Email == email);
            if (parent is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return ParentMappings.GetParentResponse(parent);
        }

        // get all parents registered on the system for a specific child
        public async Task<List<Parent>> GetAllParents(string studentId)
        {
            return await _context.Parents.Where(parent => parent.StudentId == studentId).ToListAsync();
        }

        // remove parent
        public async Task<bool> DeleteParent(string parentId)
        {
            Parent parent = await _context.Parents
            .FirstOrDefaultAsync(parent => parent.Id == parentId);
            if (parent is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }

            _context.Remove(parent);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                throw new ArgumentException("Cannot remove student at this time");
            }
            return true;
        }
    }
}