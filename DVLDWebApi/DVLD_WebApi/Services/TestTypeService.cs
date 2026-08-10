using DTOs;
using DVLD_WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class TestTypeService
    {
        private readonly DVLDContext _context;

        public TestTypeService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<TestTypeDTO>> GetAllTestTypes()
        {
            var query = _context.TestTypes.Select(c => new TestTypeDTO
            {
                TestTypeId = c.TestTypeId,
                TestTypeTitle = c.TestTypeTitle,
                TestTypeDescription = c.TestTypeDescription,
                TestTypeFees = c.TestTypeFees
            });
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TestTypeDTO> GetTestTypeById(int testTypeId)
        {
            var testType = await _context.TestTypes.AsNoTracking().FirstOrDefaultAsync(c => c.TestTypeId == testTypeId);
            if (testType != null)
            {
                return new TestTypeDTO
                {
                    TestTypeId = testType.TestTypeId,
                    TestTypeTitle = testType.TestTypeTitle,
                    TestTypeDescription = testType.TestTypeDescription,
                    TestTypeFees = testType.TestTypeFees
                };
            }
            else
            {
                throw new Exception($"Test type with ID {testTypeId} not found.");
            }
        }

        public async Task UpdateTestType(TestTypeDTO testTypeDTO)
        {
            var testType = await _context.TestTypes.FirstOrDefaultAsync(c => c.TestTypeId == testTypeDTO.TestTypeId);
            if (testType != null)
            {
                testType.TestTypeTitle = testTypeDTO.TestTypeTitle;
                testType.TestTypeDescription = testTypeDTO.TestTypeDescription;
                testType.TestTypeFees = testTypeDTO.TestTypeFees;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Test type with ID {testTypeDTO.TestTypeId} not found.");
            }

        }
    }
}
