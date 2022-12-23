//
//  Copyright 2021  2021
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public class AcademicExperienceModel: BaseAuditableEntity
    {
       
       
        public string InstitutionName { set; get; }
        public string InstitutionAddress { set; get; }
        public string ProgrammeStudied{ set; get; }
        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public string Certificate { set; get; }
        
        public int ApplicantModelID { set; get; }
        private ICollection<ApplicantModel?> ApplicantModel { get; set; }

        public AcademicExperienceModel()
        {
        }
    }
}
